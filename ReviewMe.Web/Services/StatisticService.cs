using Biosphere.Common.DataAccess.Repository;
using Biosphere.Common.DataAccess.UnitOfWork;
using ReviewMe.DataAccess.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewMe.Web.Services
{
    public class StatisticService
    {
        private readonly IRepository<Visitor> _playerRepository;

        private readonly IUnitOfWork _unitOfWork;

        public StatisticService(IRepository<Visitor> playerRepository, IUnitOfWork unitOfWork)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// В отличие от классов Monitor, Mutex и ReaderWriterLock, класс Semaphore не поддерживает сходство потоков. 
        /// Это означает, что его можно использовать в сценариях, в которых один поток получает семафор, а другой поток освобождает его.
        /// </summary>
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        /// <summary>
        /// Декаратор, для запуска выполнения действия через семафор.
        /// </summary>
        /// <param name="func">Async функция</param>
        /// <returns></returns>
        private async Task RunThreedSafe(Func<Task> func)
        {
            await _semaphore.WaitAsync();

            try
            {
                await func();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task DoAddVisitorsCount(string playerName, int value)
        {
            var player = await _playerRepository.GetAsync(x => x.Name == playerName);
            if (player == null)
            {
                player = new Visitor
                {
                    Name = playerName
                };
                _playerRepository.Add(player);
                await _unitOfWork.SaveChangesAsync();
            }
            player.Count += value;
            await _unitOfWork.SaveChangesAsync();
        }
        
        private async Task DoClearVisitorsCount(string playerName)
        {
            var player = await _playerRepository.GetAsync(x => x.Name == playerName);
            player.Count = 0;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddVisitorsCountAsync(string playerName, int value)
        {
            await RunThreedSafe(() => DoAddVisitorsCount(playerName, value));
        }

        public async Task ClearVisitorsCountAsync(string playerName)
        {
            await RunThreedSafe(() => DoClearVisitorsCount(playerName));
        }
        
        public async Task<int> GetVisitorsCountAsync(string playerName)
        {
            var player = await _playerRepository.GetAsync(x => x.Name == playerName);
            return player?.Count ?? 0;
        }
    }
}