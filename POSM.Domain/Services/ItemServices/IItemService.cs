using System.Threading.Tasks;
using POSM.EntityFramework.Models;

namespace POSM.Domain.Services.ItemServices
{
	public interface IItemService
	{
		Task<Item> GetItemById(int itemId);
	}
}
