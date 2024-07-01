using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Proyecto_App_AlmaFria.APIresponsive;
using Proyecto_App_AlmaFria.Clases;
using Proyecto_App_AlmaFria.Generic;
using Proyecto_App_AlmaFria.MVVM.Models;
using Proyecto_App_AlmaFria.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public partial class CheckoutViewModel: ObservableObject
	{


		private ObservableCollection<CartItem> _cartItems;
		public ObservableCollection<CartItem> CartItems
		{
			get => _cartItems;
			set => SetProperty(ref _cartItems, value);
		}

		private ClientModel _client;
        private PedidoService PedidoService;

        private float PrecioTotalConIgv = 0;
        private float PrecioTotalSinIgv = 0;
        private float igvTotal = 0;
        private List<string> ListaItem = new List<string>();

		private string nombre;
		private string dni;
		private string direccion;
		private string ciudad;

		public string Nombre
		{
			get => nombre;
			set => SetProperty(ref nombre, value);
		}

		public string DNI
		{
			get => dni;
			set => SetProperty(ref dni, value);
		}

		public string Direccion
		{
			get => direccion;
			set => SetProperty(ref direccion, value);
		}

		public string Ciudad
		{
			get => ciudad;
			set => SetProperty(ref ciudad, value);
		}



        public ICommand SendJsonCommand { get; }

		public CheckoutViewModel()
		{
			CartItems = new ObservableCollection<CartItem>();
            SendJsonCommand = new AsyncRelayCommand(SendJson);

			InitializeAsync().ConfigureAwait(false);
		}

		public async Task InitializeAsync()
		{
			await ObtenerCarrito();
            await ObtenerCliente();
		}

		public async Task ObtenerCarrito()
		{
			var items = CargarCarrito().Select(product => new CartItem
			{
				ID = product.ID,
				Nombre = product.Nombre,
				Precio = product.Precio,
				StockActual = product.StockActual,
				Imageurl = product.Imageurl,
				Cantidad = product.Cantidad,
				Total = product.Total
			}).ToList();

			CartItems = new ObservableCollection<CartItem>(items);
		}

		private List<CartItem> CargarCarrito()
		{
			if (Preferences.Get("carrito", "") == "")
			{
				return new List<CartItem>();
			}
			else
			{
				string valor = Preferences.Get("carrito", "");
				return JsonConvert.DeserializeObject<List<CartItem>>(valor);
			}
		}


        private async Task ObtenerCliente()
        {
            var cliente = CargarCliente();
            _client = cliente;
        }


        private ClientModel CargarCliente()
        {
			if (Preferences.Get("usuario", "") == "")
            {
				return new ClientModel();
			}
			else
            {
				string valor = Preferences.Get("usuario", "");
				return JsonConvert.DeserializeObject<ClientModel>(valor);
			}
		}


		private async Task SendJson()
		{

			CalcularValoresDePrecios();

			DateTime fechaActual = DateTime.Now;
			BoletaCLS oBoletaAux = new BoletaCLS();

			//Variables para json
			//ApiResponseLastDocument oApiResponseLasDocument = await PedidoService.getNumeroCorrelativoSig();
			//string numeroBoleta = $"{oApiResponseLasDocument.serie}-{oApiResponseLasDocument.suggestedNumber}";

            string numeroBoleta = "B001-00000070";
			string fecha = fechaActual.ToString("yyyy-MM-dd");
			string hora = fechaActual.ToString("HH:mm:ss");
			string NombresApellidos = nombre;
			string DNI = dni;
			string Direccion = direccion;

			string ItemsParaConcatenar = string.Join(", \n", ListaItem);

			string json = $@"  
    {{
        ""personaId"": ""66638b197bdd6e00156c3943"",
        ""personaToken"": ""DEV_DW7atRvhC9eSXtofPJ65kH8BhT14l0YwdoqhuJOoYKVpCJpzaBUGQ7LjO7XGpeoO"",
        ""fileName"": ""20331429601-03-{numeroBoleta}"",
        ""documentBody"": {{
            ""cbc:UBLVersionID"": {{
                ""_text"": ""2.1""
            }},
            ""cbc:CustomizationID"": {{
                ""_text"": ""2.0""
            }},
            ""cbc:ID"": {{
                ""_text"": ""{numeroBoleta}""
            }},
            ""cbc:IssueDate"": {{
                ""_text"": ""{fecha}""
            }},
            ""cbc:IssueTime"": {{
                ""_text"": ""{hora}""
            }},
            ""cbc:InvoiceTypeCode"": {{
                ""_attributes"": {{
                    ""listID"": ""0101""
                }},
                ""_text"": ""03""
            }},
            ""cbc:Note"": [
                {{
                    ""_text"": ""VEINTITRES CON 60/100 SOLES"",
                    ""_attributes"": {{
                        ""languageLocaleID"": ""1000""
                    }}
                }}
            ],
            ""cbc:DocumentCurrencyCode"": {{
                ""_text"": ""PEN""
            }},
            ""cac:AccountingSupplierParty"": {{
                ""cac:Party"": {{
                    ""cac:PartyIdentification"": {{
                        ""cbc:ID"": {{
                            ""_attributes"": {{
                                ""schemeID"": ""6""
                            }},
                            ""_text"": ""20331429601""
                        }}
                    }},
                    ""cac:PartyLegalEntity"": {{
                        ""cbc:RegistrationName"": {{
                            ""_text"": ""TOTAL ARTEFACTOS SA""
                        }},
                        ""cac:RegistrationAddress"": {{
                            ""cbc:AddressTypeCode"": {{
                                ""_text"": ""0000""
                            }},
                            ""cac:AddressLine"": {{
                                ""cbc:Line"": {{
                                    ""_text"": ""AV. EL DERBY NRO. 254 SANTIAGO DE SURCO LIMA LIMA""
                                }}
                            }}
                        }}
                    }}
                }}
            }},
            ""cac:AccountingCustomerParty"": {{
                ""cac:Party"": {{
                    ""cac:PartyIdentification"": {{
                        ""cbc:ID"": {{
                            ""_attributes"": {{
                                ""schemeID"": ""1""
                            }},
                            ""_text"": ""{DNI}""
                        }}
                    }},
                    ""cac:PartyLegalEntity"": {{
                        ""cbc:RegistrationName"": {{
                            ""_text"": ""{NombresApellidos}""
                        }},
                        ""cac:RegistrationAddress"": {{
                            ""cac:AddressLine"": {{
                                ""cbc:Line"": {{
                                    ""_text"": ""{Direccion}""
                                }}
                            }}
                        }}
                    }}
                }}
            }},
            ""cac:TaxTotal"": {{
                ""cbc:TaxAmount"": {{
                    ""_attributes"": {{
                        ""currencyID"": ""PEN""
                    }},
                    ""_text"": {(float)Math.Round(igvTotal, 2)}
                }},
                ""cac:TaxSubtotal"": [
                    {{
                        ""cbc:TaxableAmount"": {{
                            ""_attributes"": {{
                                ""currencyID"": ""PEN""
                            }},
                            ""_text"": {(float)Math.Round(PrecioTotalSinIgv, 2)}
                        }},
                        ""cbc:TaxAmount"": {{
                            ""_attributes"": {{
                                ""currencyID"": ""PEN""
                            }},
                            ""_text"": {(float)Math.Round(igvTotal, 2)}
                        }},
                        ""cac:TaxCategory"": {{
                            ""cac:TaxScheme"": {{
                                ""cbc:ID"": {{
                                    ""_text"": ""1000""
                                }},
                                ""cbc:Name"": {{
                                    ""_text"": ""IGV""
                                }},
                                ""cbc:TaxTypeCode"": {{
                                    ""_text"": ""VAT""
                                }}
                            }}
                        }}
                    }}
                ]
            }},
            ""cac:LegalMonetaryTotal"": {{
                ""cbc:LineExtensionAmount"": {{
                    ""_attributes"": {{
                        ""currencyID"": ""PEN""
                    }},
                    ""_text"": {(float)Math.Round(PrecioTotalSinIgv, 2)}
                }},
                ""cbc:TaxInclusiveAmount"": {{
                    ""_attributes"": {{
                        ""currencyID"": ""PEN""
                    }},
                    ""_text"": {PrecioTotalConIgv}
                }},
                ""cbc:PayableAmount"": {{
                    ""_attributes"": {{
                        ""currencyID"": ""PEN""
                    }},
                    ""_text"": {PrecioTotalConIgv}
                }}
            }},
            ""cac:InvoiceLine"": [
                {ItemsParaConcatenar}
            ]
        }}
    }}";


			oBoletaAux.Nombre = NombresApellidos;
			oBoletaAux.DNI = DNI;
			oBoletaAux.Hora = hora;
			//oBoletaAux.Serie = oApiResponseLasDocument.serie;
			//oBoletaAux.NumeroCorrelativo = oApiResponseLasDocument.suggestedNumber;

            HttpClient httpClient = new HttpClient();
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsJsonAsync("https://back.apisunat.com/personas/v1/sendBill", content);

 
		}

		private void CalcularValoresDePrecios()
		{
			int idItem = 1;
			foreach (CartItem i in CartItems)
			{

				PrecioTotalConIgv += (float)i.Total;
				string ItemAux = $@"
                    {{
                        ""cbc:ID"": {{
                            ""_text"": {idItem}
                        }},
                        ""cbc:InvoicedQuantity"": {{
                            ""_attributes"": {{
                                ""unitCode"": ""NIU""
                            }},
                            ""_text"": {i.Cantidad}
                        }},
                        ""cbc:LineExtensionAmount"": {{
                            ""_attributes"": {{
                                ""currencyID"": ""PEN""
                            }},
                            ""_text"": {(float)Math.Round((float)i.Total / 1.18, 2)}
                        }},
                        ""cac:PricingReference"": {{
                            ""cac:AlternativeConditionPrice"": {{
                                ""cbc:PriceAmount"": {{
                                    ""_attributes"": {{
                                        ""currencyID"": ""PEN""
                                    }},
                                    ""_text"": {i.Precio}// precio unidad precio dde vena
                                }},
                                ""cbc:PriceTypeCode"": {{
                                    ""_text"": ""01""
                                }}
                            }}
                        }},
                        ""cac:TaxTotal"": {{
                            ""cbc:TaxAmount"": {{
                                ""_attributes"": {{
                                    ""currencyID"": ""PEN""
                                }},
                                ""_text"": {(float)Math.Round((float)i.Total - ((float)i.Total / 1.18), 2)}
                            }},
                            ""cac:TaxSubtotal"": [
                                {{
                                    ""cbc:TaxableAmount"": {{
                                        ""_attributes"": {{
                                            ""currencyID"": ""PEN""
                                        }},
                                        ""_text"": {(float)Math.Round((float)i.Total / 1.18, 2)}
                                    }},
                                    ""cbc:TaxAmount"": {{
                                        ""_attributes"": {{
                                            ""currencyID"": ""PEN""
                                        }},
                                        ""_text"": {(float)Math.Round((float)i.Total - ((float)i.Total / 1.18), 2)}
                                    }},
                                    ""cac:TaxCategory"": {{
                                        ""cbc:Percent"": {{
                                            ""_text"": 18
                                        }},
                                        ""cbc:TaxExemptionReasonCode"": {{
                                            ""_text"": ""10""
                                        }},
                                        ""cac:TaxScheme"": {{
                                            ""cbc:ID"": {{
                                                ""_text"": ""1000""
                                            }},
                                            ""cbc:Name"": {{
                                                ""_text"": ""IGV""
                                            }},
                                            ""cbc:TaxTypeCode"": {{
                                                ""_text"": ""VAT""
                                            }}
                                        }}
                                    }}
                                }}
                            ]
                        }},
                        ""cac:Item"": {{
                            ""cbc:Description"": {{
                                ""_text"": ""{i.Nombre}""
                            }}
                        }},
                        ""cac:Price"": {{
                            ""cbc:PriceAmount"": {{
                                ""_attributes"": {{
                                    ""currencyID"": ""PEN""
                                }},
                                ""_text"": {(float)Math.Round((float)i.Precio / 1.18, 2)}
                            }}
                        }}
                    }}";

				ListaItem.Add(ItemAux);
				idItem++;
			}


			PrecioTotalSinIgv = PrecioTotalConIgv / 1.18f;
			igvTotal = PrecioTotalConIgv - PrecioTotalSinIgv;
		}



	}
	
}
