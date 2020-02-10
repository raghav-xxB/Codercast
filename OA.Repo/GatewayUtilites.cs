using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public class GatewayUtilites<T> where T : Entity
    {
        private Dictionary<string, T> entities;
        public GatewayUtilites()
        {
            this.entities = new Dictionary<string, T>();
        }

        public List<T> getEntities()
        {
            List<T> clonedEntities = new List<T>();
            foreach (T entity in entities.Values)
            {
                addCloneToList(entity, clonedEntities);
            }
            return clonedEntities;
        }

        private void addCloneToList(T entity, List<T> newEntities)
        {
            T newValue = entity;
            newEntities.Add((T) newValue);
        }

        public T save(T entity)
        {
            if (entity.ID == null)
                entity.ID = Guid.NewGuid().ToString();
            string id = entity.ID;
            saveCloneInMap(id, entity);
            return entity;
        }

        private void saveCloneInMap(string id, T entity)
        {
           // entities.Clear();
            T newValue = entity;
           // entities.Add(id,(T) newValue);
            entities[id] = newValue;
        }

        public void delete(T entity)
        {
            entities.Remove(entity.ID);
        }
    }
}
