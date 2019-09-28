using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contract;
using Market.Entities.Interfaces;
using Market.Entities.ShouldMap;

namespace Market.Services
{
    public class RackItemLevelServices
    {
        private IRackItemLevelRepository irackItemLevelRepository { get; set; }
        private IItemRepository iiItemRepository { get; set; }

        private IRackRepository IRackRepository { get; set; } 


        public void CreateAndUpdateRackItemLevel(RackItemLevelContract rackItemLevelContract)
        {
            var rackitemlevel = irackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackitemlevel != null)
            {
                rackitemlevel.CurrentQty = rackItemLevelContract.CurrentQty;
                rackitemlevel.InQty = rackItemLevelContract.InQty;
                rackitemlevel.OutQty = rackItemLevelContract.OutQty;
                rackitemlevel.Item1 = iiItemRepository.Get(rackItemLevelContract.ItemId);
                rackitemlevel.Rack1 = IRackRepository.Get(rackItemLevelContract.RackId);
                
            

                irackItemLevelRepository.Update(rackitemlevel);
            }
            else
            {
                RackItemLevel rackItemLevel = new RackItemLevel();
                rackItemLevel.CurrentQty = rackItemLevelContract.CurrentQty;
                rackItemLevel.InQty = rackItemLevelContract.InQty;
                rackItemLevel.OutQty = rackItemLevelContract.OutQty;
                rackItemLevel.Item1 = iiItemRepository.Get(rackItemLevelContract.ItemId);
                rackItemLevel.Rack1 = IRackRepository.Get(rackItemLevelContract.RackId);

                irackItemLevelRepository.Insert(rackItemLevel);
            }
        }

        public void Delete(RackItemLevelContract rackItemLevelContract)
        {
            var rackitemlevel = irackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackitemlevel != null)
            {
                irackItemLevelRepository.Delete(rackitemlevel);
            }
            
        }
    }
}
