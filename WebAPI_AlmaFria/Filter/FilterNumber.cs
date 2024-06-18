namespace WebAPI_AlmaFria.Filter
{
	public class FilterNumber : IEndpointFilter
	{
		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			int valor = context.GetArgument<int>(0);
			if (valor <= 0)
			{
				return Results.Problem("El valor debe ser mayor o igual a 1", statusCode: 400);
			}
			return await next(context);
		}
	}
}
