﻿namespace Catalog.API.Products.GetProductById
{
	public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

	public record GetProductByIdResult(Product Product);

	internal class CreateProductByIdQueryHandler(IDocumentSession session, ILogger<CreateProductByIdQueryHandler> logger) 
		: IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
	{
		public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
		{
			logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);

			var product = await session.LoadAsync<Product>(query.id, cancellationToken);

			if (product is null)
			{
				throw new ProductNotFoundException();
			}

			return new GetProductByIdResult(product);
		}
	}
}
