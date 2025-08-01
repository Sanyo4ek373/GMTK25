using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class ResourcesModel
    {
        public event Action<Resource> OnChangeResource;
        
        [Serializable]
        public struct KeyValueResource
        {
            public Resource Resource;
            public int Amount;
        }

        public List<KeyValueResource> Resources;

        public void AddResource(Resource resource, int amount)
        {
            var index = Resources.FindIndex(item => item.Resource == resource);
            if (index != -1)
            {
                var temp = Resources[index];
                temp.Amount += amount;
                Resources[index] = temp;
            }
            else
            {
                Resources.Add(new KeyValueResource
                {
                    Resource = resource,
                    Amount = amount
                });
            }
                
            OnChangeResource?.Invoke(resource);
        }
    }
}