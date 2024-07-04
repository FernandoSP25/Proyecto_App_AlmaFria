using Newtonsoft.Json;
using Proyecto_App_AlmaFria.APIresponsive;
using Proyecto_App_AlmaFria.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.Services
{
	public class PedidoService
	{
		//private readonly HttpClient _httpClient;
		////List<Pedidos> Lista;
		//List<BoletaCLS> ListaBoletas;
		//public PedidoService(HttpClient httpClient)
		//{

		//	_httpClient = httpClient;
		//	Lista = new List<Pedidos>();
		//	ListaBoletas = new List<BoletaCLS>();
		//}

		//public void Agregar(Pedidos oPedido)
		//{
		//	this.Lista.Add(oPedido);
		//}

		//public async Task sendBoleta(string json, BoletaCLS oBoletaAux)
		//{

		//	var response = await _httpClient.PostAsJsonAsync("api/Sunat/", json);

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var responseContent = await response.Content.ReadAsStringAsync();
		//		var apiResponse = JsonConvert.DeserializeObject<ApiResponseSendBill>(responseContent);
		//		ListaBoletas.Add(new BoletaCLS { Nombre = oBoletaAux.Nombre, DNI = oBoletaAux.DNI, Hora = oBoletaAux.Hora, Serie = oBoletaAux.Serie, NumeroCorrelativo = oBoletaAux.NumeroCorrelativo, Status = apiResponse.Status, DocumentId = apiResponse.DocumentId, Xml = apiResponse.Xml });
		//		Console.WriteLine("Satisfactorio");
		//		Console.WriteLine($"Status: {apiResponse.Status}");
		//		Console.WriteLine($"Document ID: {apiResponse.DocumentId}");
		//		Console.WriteLine($"XML URL: {apiResponse.Xml}");
		//	}
		//	else
		//	{
		//		Console.WriteLine("Sin santisfactorio");
		//	}
		//}

		//public async Task<ApiResponseLastDocument> getNumeroCorrelativoSig()
		//{
		//	var content = new StringContent("", Encoding.UTF8, "application/json");
		//	var response = await _httpClient.PostAsJsonAsync("api/Sunat/sendNumCorrelativoBoleta", content);
		//	if (response.IsSuccessStatusCode)
		//	{
		//		var responseContent = await response.Content.ReadAsStringAsync();
		//		var apiResponse = JsonConvert.DeserializeObject<ApiResponseLastDocument>(responseContent);
		//		Console.WriteLine("Satisfactorio");
		//		return apiResponse;
		//	}
		//	else
		//	{
		//		Console.WriteLine("Sin santisfactorio");
		//		return null;
		//	}
		//}

		//public async Task<byte[]> getBoletaPDF(string DocumentID, string SerieNumCorre)
		//{
		//	//Console.WriteLine("PedidoService:");
		//	//Console.WriteLine($"DocumentID: {DocumentID}");
		//	//Console.WriteLine($"SerieNumeroCorr: {SerieNumCorre}");
		//	//var response = await _httpClient.GetAsync($"api/Sunat?DocumentID={DocumentID}&SerieNumCorre={SerieNumCorre}");
		//	//response.EnsureSuccessStatusCode();
		//	//return await response.Content.ReadAsByteArrayAsync();
		//}

		//public async Task<DniResponse> getDatosDNIAPIPERU(string DNI)
		//{
		//	var response = await _httpClient.GetAsync($"api/APIPERU/RecuperarDatosDNI/{DNI}");
		//	response.EnsureSuccessStatusCode();
		//	string jsonResponse = await response.Content.ReadAsStringAsync();
		//	var dniResponse = JsonConvert.DeserializeObject<DniResponse>(jsonResponse);
		//	return dniResponse;
		//}
		//public async Task<RucResponse> getDatosRUCAPIPERU(string RUC)
		//{
		//	var response = await _httpClient.GetAsync($"api/APIPERU/RecuperarDatosRUC/{RUC}");
		//	response.EnsureSuccessStatusCode();
		//	string jsonResponse = await response.Content.ReadAsStringAsync();
		//	var dniResponse = JsonConvert.DeserializeObject<RucResponse>(jsonResponse);
		//	return dniResponse;
		//}
		//public List<Pedidos> getLista()
		//{
		//	return this.Lista;
		//}

		//public List<BoletaCLS> getListaBoletas()
		//{
		//	return this.ListaBoletas;
		//}

	}
}
