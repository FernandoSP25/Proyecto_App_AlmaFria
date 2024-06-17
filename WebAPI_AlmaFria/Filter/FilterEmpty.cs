namespace WebAPI_AlmaFria.Filter
{
	public class FilterEmpty : IEndpointFilter
	{
		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			string valor = context.GetArgument<string>(0);
			if (valor == null || valor.Trim() == "")
			{
				return Results.Problem("El valor no puede ser vacío", statusCode: 400);
			}
			return await next(context);
		}
	}
}
