using Market.Entities.Interfaces;
using Market.Entities.ShouldMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contract;

namespace Market.Services
{
    public class ItemServices 
    {
        private IItemRepository iitItemRepository { get; set; }

        public void CreateAndUpdate(ItemContract itemContract)
        {
            var item = iitItemRepository.Get(itemContract.Id);
            if (item != null)
            {
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                iitItemRepository.Update(item);
            }
            else
            {
               Item item1 = new Item();

               item1.Name = itemContract.Name;
               item1.Unit = itemContract.Unit;

               iitItemRepository.Insert(item1);
            }
        }

        public void Delete(ItemContract itemcontract)
        {
            var item = iitItemRepository.Get(itemcontract.Id);

            iitItemRepository.Delete(item);
        }
    }


        

}
