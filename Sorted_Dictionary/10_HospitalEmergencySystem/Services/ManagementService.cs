using System;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<BaseEntity>> _data
            = new SortedDictionary<int, List<BaseEntity>>();

        public void AddEntity(int key, BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // Validate entity
            entity.Validate();

            // Check if key exists
            if (!_data.ContainsKey(key))
            {
                _data[key] = new List<BaseEntity>();
            }

            // Prevent duplicate Id
            foreach (var item in _data[key])
            {
                if (item.Id == entity.Id)
                    throw new ScenarioException("Duplicate entity Id not allowed.");
            }

            _data[key].Add(entity);
        }

        public void UpdateEntity(int key)
        {
            if (!_data.ContainsKey(key))
                throw new KeyNotFoundException("Key not found.");

            foreach (var entity in _data[key])
            {
                Console.Write($"Enter new Id for {entity.Id}: ");
                string newId = Console.ReadLine();

                entity.Id = newId;
                entity.Validate();
            }
        }

        public void RemoveEntity(int key)
        {
            if (!_data.ContainsKey(key))
                throw new KeyNotFoundException("Key not found.");

            _data.Remove(key);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            foreach (var pair in _data)
            {
                foreach (var entity in pair.Value)
                {
                    yield return entity;
                }
            }
        }
    }
}
