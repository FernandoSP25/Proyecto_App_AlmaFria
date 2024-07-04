
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.Services
{
	public class EmailVerificationService
	{
		//private readonly string apiKey = "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";


		//public async Task<bool> ValidateEmailAddress(string email)
		//{
		//	var client = new SendGridClient(apiKey);

		//	var data = $@"{{
  //              ""source"": ""User Registration"",
  //              ""email"": ""{email}""
  //          }}";

		//	var response = await client.RequestAsync(
		//		method: SendGridClient.Method.POST,
		//		urlPath: "validations/email",
		//		requestBody: data
		//	);


		//	await App.Current.MainPage.DisplayAlert("Alert", "Email Verification Service" + response.StatusCode 
		//		+ response.Body.ReadAsStringAsync().Result + " " + response.Headers.ToString(), "OK");
		//	Console.WriteLine(response.StatusCode);
		//	Console.WriteLine(response.Body.ReadAsStringAsync().Result);
		//	Console.WriteLine(response.Headers.ToString());

		//	if (response.StatusCode == System.Net.HttpStatusCode.OK)
		//	{
		//		var content = await response.Body.ReadAsStringAsync();
		//		Console.WriteLine($"Email Validation Response: {content}");
		//		return true; // Validación exitosa
		//	}
		//	else
		//	{
		//		Console.WriteLine($"Error: {response.StatusCode}");
		//		return false; // Validación fallida
		//	}
		//}


		public static async Task Execute()
		{
			var apiKey = "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";


			// Crear cliente de SendGrid con la API Key
			var client = new SendGridClient(apiKey);

			// Configurar la información del correo electrónico
			var from = new EmailAddress("dsolanoporto@gmail.com", "Alma Fria Proyecto");  // Cambia esto a tu dirección de remitente
			var subject = "Verificación de correo electrónico";  // Asunto del correo electrónico
			var to = new EmailAddress("courtneylucerovacahonores@gmail.com", "fernando");  // Cambia esto a la dirección de correo del destinatario
			var plainTextContent = "Por favor, verifica tu correo electrónico haciendo clic en el siguiente enlace";  // Contenido en texto plano
			var htmlContent = "<strong>Por favor, verifica tu correo electrónico haciendo clic en el siguiente enlace: </strong>";  // Contenido en HTML

			// Crear el mensaje de correo electrónico
			var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

			// Enviar el correo electrónico
			var response = await client.SendEmailAsync(msg);

			// Mostrar el resultado de la solicitud
			Console.WriteLine(response.StatusCode);
			Console.WriteLine(await response.Body.ReadAsStringAsync());
			Console.WriteLine(response.Headers.ToString());
		}




	}
}
