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
                throw new ScenarioException("Entity cannot be null.");

            // Validate entity
            entity.Validate();

            // Create key if not exists
            if (!_data.ContainsKey(key))
            {
                _data[key] = new List<BaseEntity>();
            }

            // Prevent duplicate Id under same key
            foreach (var item in _data[key])
            {
                if (item.Id == entity.Id)
                    throw new ScenarioException("Duplicate Order Id not allowed.");
            }

            _data[key].Add(entity);
        }

        public void UpdateEntity(int key)
        {
            if (!_data.ContainsKey(key))
                throw new ScenarioException("Priority key not found.");

            foreach (var entity in _data[key])
            {
                Console.Write($"Enter new Id for Order {entity.Id}: ");
                string newId = Console.ReadLine() ?? "";

                entity.Id = newId;
                entity.Validate();
            }
        }

        public void RemoveEntity(int key)
        {
            if (!_data.ContainsKey(key))
                throw new ScenarioException("Priority key not found.");

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
