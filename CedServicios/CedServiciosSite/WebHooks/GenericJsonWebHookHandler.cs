using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;


namespace CedServicios.Site.WebHooks
{
    public class GenericJsonWebHookHandler : WebHookHandler
    {
        public GenericJsonWebHookHandler()
        {
            this.Receiver = GenericJsonWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            // Get JSON from WebHook
            JObject data = context.GetDataOrDefault<JObject>();

            // Get the action for this WebHook coming from the action query parameter in the URI
            string action = context.Actions.FirstOrDefault();


            string path = string.Format("webhook-{0}.json", System.DateTime.Now.ToString("yyyMMddHHmmss"));
            using (StreamWriter file = File.CreateText(System.Web.HttpContext.Current.Server.MapPath(path)))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                data.WriteTo(writer);
            }

            //con el post_id ir a buscar detalle de la orden con las webapi
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(data.ToString());
            ListarPedidoSync(myDeserializedClass.PostId).Wait();
            return Task.FromResult(true);
        }

        private static async Task ListarPedido(int Id)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestAPI rest = new RestAPI("https://www.staging1.pizzapress.com.ar/wp-json/wc/v2/", "ck_3fed2bfd124c0d6f803e20616b76bf84a82675be", "cs_94a2937a7d1f3ebc7b00d1c084992155351a7ba3");
            WCObject wc = new WCObject(rest);

            var pedido = await wc.Order.Get(Id);
            foreach (OrderLineItem item in pedido.line_items)
            {
                string sku = item.sku;
                decimal? cantidad = item.quantity;
                decimal? precio = item.price;
            }
        }

        private static Task ListarPedidoSync(int Id)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestAPI rest = new RestAPI("https://www.staging1.pizzapress.com.ar/wp-json/wc/v2/", "ck_3fed2bfd124c0d6f803e20616b76bf84a82675be", "cs_94a2937a7d1f3ebc7b00d1c084992155351a7ba3");
            WCObject wc = new WCObject(rest);

            Order pedido = wc.Order.Get(Id).GetAwaiter().GetResult();
            string path = string.Format("pedido-{0}.txt", pedido.id);
            System.IO.File.AppendAllText(System.Web.HttpContext.Current.Server.MapPath(path), string.Format("{0}----------{1}---------------- ", System.Environment.NewLine, System.DateTime.Now.ToLocalTime()));
            foreach (OrderLineItem item in pedido.line_items)
            {
                string sku = item.sku;
                decimal? cantidad = item.quantity;
                decimal? precio = item.price;
                string log = string.Format("Estado:{5}{4}SKU:{0}{4}Cantidad:{1}{4}Precio:{2}{4}Descripcion:{3}{4}", item.sku, item.quantity, item.price, item.name, System.Environment.NewLine, pedido.status);
                System.IO.File.AppendAllText(System.Web.HttpContext.Current.Server.MapPath(path), log);
            }
            return Task.FromResult(true);
        }
    }
}
