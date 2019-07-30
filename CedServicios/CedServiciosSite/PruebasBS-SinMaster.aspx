<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebasBS-SinMaster.aspx.cs" Inherits="CedServicios.Site.PruebasBS_SinMaster" Theme="CedServicios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="data:text/css;charset=utf-8," data-href="css/bootstrap-theme.min.css" rel="stylesheet" id="bsthemestylesheet">

    <style type="text/css">
        .Fuente
        {
        	font-family: Verdana;
        	font-size: 10px;
        	color: Navy;
        }
        .gi-1x{font-size: 1em;}
        .gi-1-5x{font-size: 1.5em;}
        .gi-2x{font-size: 2em;}
        .gi-3x{font-size: 3em;}
        .gi-4x{font-size: 4em;}
        .gi-5x{font-size: 5em;}
        .center-block {  
          display: block;  
          margin-right: auto;  
          margin-left: auto;  
        } 
    </style>
    
</head>
<body>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="http://getbootstrap.com/assets/js/docs.min.js"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $("#example").popover({
                placement: 'bottom',
                html: 'true',
                title: '<span class="text-info"><strong>title!! </strong></span> <button type="button" id="close" class="close">&times;</button></span>',
                content: 'test'
            })

            $(document).on('click', '#close', function (event) {
                $("#example").popover('hide');
                $("#example").focus();
            });
            $("#close").click(function (event) {
                $("#example").popover('hide');
            });
        });
    </script>

    <form id="form1" runat="server">
        <br />  
        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
          Launch demo modal
        </button>

        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Modal title</h4>
              </div>
              <div class="modal-body">
                ...
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
              </div>
            </div>
          </div>
        </div>
        <br />
        <br />
        <a href="#" id="Example" role="button" class="popover-test" data-html="true" title="DATOS DEL VENDEDOR &nbsp;&nbsp;&nbsp;<a href='#' role='button' onclick='CierroPopup()'><span id='Icono' class='glyphicon glyphicon-remove gi-1x' style='vertical-align: top; text-align: right'></span></a>" data-content="En esta página se registran todos los datos de la persona que emitirá facturas de venta.<br><br><div class='popover-footer'><a href='#' class='btn btn-info btn-sm'>Close</a></div><br>"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <button type="button" id="example" class="btn btn-primary"></button>
    </form>
</body>
</html>
