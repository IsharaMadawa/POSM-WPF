using POSM.Domain.Exceptions;
using POSM.EntityFramework.Models;
using System.Threading.Tasks;

namespace POSM.Domain.Services.ItemServices
{
	public class ItemSevice : IItemService
	{
		private readonly IItemService _itemService;

		public ItemSevice(IItemService itemService)
		{
			_itemService = itemService;
		}

		public async Task<Item> GetItemById(int itemId)
		{
			Item selectedItem = await _itemService.GetItemById(itemId);

			if (selectedItem == null)
			{
				throw new ItemNotFoundException(itemId);
			}

			return selectedItem;
		}
	}
}
