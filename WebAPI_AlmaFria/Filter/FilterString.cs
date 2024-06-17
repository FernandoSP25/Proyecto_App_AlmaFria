namespace WebAPI_AlmaFria.Filter
{
	public class FilterString : IEndpointFilter
	{
		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			string valor = context.GetArgument<string>(0);
			bool exito = valor.All(char.IsLetter);
			if (exito == false)
			{
				return Results.Problem("El valor debe ser letras", statusCode: 400);
			}
			return await next(context);
		}
	}
}
