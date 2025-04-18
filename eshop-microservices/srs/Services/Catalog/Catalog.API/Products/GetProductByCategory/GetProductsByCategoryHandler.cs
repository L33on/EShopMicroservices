namespace Catalog.API.Products.GetProductByCategory
{
	public record GetProductsByCategoryQuery(string category) : IQuery<GetProductsByCategoryResult>;

	public record GetProductsByCategoryResult(IEnumerable<Product> Products);

	internal class CreateProductsByCategoryQueryHandler(IDocumentSession session) 
		: IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
	{
		public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
		{
			var products = await session.Query<Product>()
				.Where(p => p.Category.Contains(query.category))
				.ToListAsync();

			return new GetProductsByCategoryResult(products);
		}
	}
}
