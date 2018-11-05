using System.Collections.Generic;
using System.Linq;

namespace TeslaGame.Models
{
    public class Cart
    {
		public List<CartLine> lineCollection = new List<CartLine>();

		public virtual void AddItem(Product product, int quantity)
		{
			CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
			if (line == null)
			{
				lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
			}
			else line.Quantity += quantity;
		}

		public virtual void RemoveLive(Product product) =>
			lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

		public virtual void ComputeTotalValue(Product product) =>
			lineCollection.Sum(p => p.Product.Price * p.Quantity);

		public virtual void Clear() => lineCollection.Clear();

		public virtual IEnumerable<CartLine> Lines => lineCollection;
	}

	public class CartLine
	{
		public int CardID { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
