using Basket.API.Models;

namespace Basket.API.Basket.GetBasket
{
	public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
	public record GetBasketResult(ShoppingCart Basket);

	public class GetBasketHandler
		: IQueryHandler<GetBasketQuery, GetBasketResult>
	{
		private readonly IBasketRepository _basketRepository;
		public GetBasketHandler(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}
		public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
		{
			var basket = await _basketRepository.GetBasketAsync(request.UserName, cancellationToken);
			return new GetBasketResult(basket);
		}
	}
}
