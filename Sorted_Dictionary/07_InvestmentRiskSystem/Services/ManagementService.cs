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

            // If key doesn't exist, create new list
            if (!_data.ContainsKey(key))
            {
                _data[key] = new List<BaseEntity>();
            }

            // Check duplicate Id under same key
            foreach (var item in _data[key])
            {
                if (item.Id == entity.Id)
                    throw new ScenarioException("Duplicate Order Id under same priority.");
            }

            _data[key].Add(entity);
        }

        public void UpdateEntity(int key)
        {
            if (!_data.ContainsKey(key) || _data[key].Count == 0)
                throw new ScenarioException("No entity found for this key.");

            // Simple update example: change Id of first entity
            _data[key][0].Id += "_Updated";
        }

        public void RemoveEntity(int key)
        {
            if (!_data.ContainsKey(key))
                throw new ScenarioException("Key not found.");

            _data.Remove(key);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            List<BaseEntity> result = new List<BaseEntity>();

            foreach (var pair in _data)
            {
                foreach (var entity in pair.Value)
                {
                    result.Add(entity);
                }
            }

            return result;
        }
    }
}
