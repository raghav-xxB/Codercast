namespace OA.Data
{
    public class Entity
    {
        private string Id;
        public string ID { get => Id; set => Id = value; }

        public bool isSame(Entity entity)
        {
            return ID != null && object.Equals(ID, entity.ID);
        }
    }
}