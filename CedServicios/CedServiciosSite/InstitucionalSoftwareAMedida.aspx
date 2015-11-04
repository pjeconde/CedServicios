<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalSoftwareAMedida.aspx.cs" Inherits="CedServicios.Site.InstitucionalSoftwareAMedida" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container-fluid">
    <div class="row text-left">
        <div class="col-lg-12">
        <p>
            <br />
            <span class="glyphicon glyphicon-home" style="vertical-align: top; padding-top: 10px;"></span> <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Desarrollo de Software a Medida"></asp:Label>
        </p>
        <p>
            El gran número de ventajas de informatizar los procesos de gestión en las empresas es incuestionable.<br /> 
            Cuando necesitamos informatizar dichos procesos podemos optar por dos opciones:
        </p>
        <ul>
          <li>Usar un software desarrollado a medida del proceso a implementar</li>
          <li>Usar un software comercial que ya implemente las funciones necesarias</li>
        </ul>
        <p>
            Veamos rápidamente las ventajas y desventajas de ambos tipos de software.
            Como introducción indicar que un software a medida tendrá que ser implementado por expertos informáticos (consultores, analistas y programadores informáticos) y el software comercial se comprará ya desarrollado y tendremos que adaptar nuestra empresa a dicho software.
        </p>
        <p>
            Para realizar la comparativa vamos a comparar las siguientes 8 dimensiones: adaptación, formación, optimización, implicación, tiempo, coste, disponibilidad y evolución.
        </p>
        <h4>Características del software a medida:</h4>
        <ul>
            <li><b><span>Adaptación:</span></b> Se adaptará perfectamente a la empresa ya que los expertos informáticos harán un diseño y posteriormente un desarrollo preciso para dicha empresa.</li>
            <li><b><span>Formación de gestión:</span></b> El esfuerzo para aprender a manejar el software será bajo ya que se realizará manteniendo reuniones con los profesionales de la empresa que lo van a usar y ellos mismos participarán en el desarrollo.</li>
            <li><b><span>Optimización:</span></b> Tendrá una optimización muy alta y se evitarán procesos redundantes. El grado de uso de funcionalidades será del 100%.</li>
            <li><b><span>Implicación de los gestores:</span></b> Necesitaremos una implicación alta de los profesionales de la empresa a la hora de probar y verificar que el software cumple con los requisitos acordados inicialmente y así tendremos una solución personalizada para nuestra empresa. También dichos gestores deberán dar sugerencias a los expertos informáticos durante el desarrollo para que éste sea mejor.</li>
            <li><b><span>Tiempo de implantación:</span></b> El tiempo de desarrollo puede ser alto dependiendo del nivel de complejidad de la solución a implementar.</li>
            <li><b><span>Costo:</span></b> El costo de implantación será más elevado en comparación con el software comercial, pero el software a medida debe implicar que en un futuro se necesiten menos recursos en la empresa para realizar los procesos de gestión al estar más optimizado que el software genérico, con lo que el costo global será habitualmente menor.</li>
            <li><b><span>Disponibilidad:</span></b> Siempre podremos desarrollar una solución a medida para resolver un proceso de gestión.</li>
            <li><b><span>Evolución:</span></b> El software a medida podrá ser evolucionado a medida que vaya habiendo nuevas necesidades en la empresa.</li>
        </ul>
        <h4>Características del software comercial:</h4>
        <ul>
            <li><b><span>Adaptación:</span></b> Puede que la adaptación a la empresa no sea tan alta como el software  a medida ya que tendría que coincidir que para el proceso de gestión a realizar haya un software comercial que implemente dichas funciones.
            <li><b><span>Formación de gestión:</span></b> Requerirá un esfuerzo alto en la formación de los profesionales de la empresa que lo van a utilizar ya que se tratará de un software nuevo para ellos (y en cuyo desarrollo no han participado).
            <li><b><span>Optimización:</span></b> La optimización en la mayoría de los casos será menor que en el software a medida aunque puede haber soluciones en las que haya un software comercial de gran calidad.
            <li><b><span>Implicación de los gestores:</span></b> Los profesionales que manejen la herramienta no tendrán que implicarse en el desarrollo ya que dicha herramienta ya está desarrollada.
            <li><b><span>Tiempo de implantación:</span></b> El tiempo de implantación dependerá del tiempo que necesiten los profesionales para la formación, pero no tendremos tiempo de desarrollo al estar la aplicación desarrollada.
            <li><b><span>Costo:</span></b> Normalmente el gasto en licencias de software comercial será menor que el gasto en los expertos informáticos, pero la herramienta comercial suele tener un grado de optimización menor con lo que a la larga la puede ser más cara.
            <li><b><span>Disponibilidad:</span></b> hay casos para los que no hay soluciones comerciales ya implementadas y la única solución es contratar un equipo informático que nos desarrollen un software a medida.
            <li><b><span>Evolución:</span></b> la única forma que tendremos de evolucionar el software comercial será que la empresa desarrolladora saque al mercado nuevos módulos que se ajusten con nuestros nuevos procesos de gestión.
        </ul>
        <p>
            En general podemos concluir que si los grados de especialización y evolución constante son altos, necesitaremos un software a medida y un software comercial si dichos grados no son tan altos.
        </p>
        <p>
            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
        </p>
        </div>
    </div>
    </div>
     <script type="text/javascript">
         function BorrarMensaje() {
             {
                 document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
             }
         }
    </script>
</asp:Content>


    