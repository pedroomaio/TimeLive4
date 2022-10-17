<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="AbsenceMap.aspx.vb" Inherits="Employee_AbsenceMap" Title ="AbsenceMap" EnableViewState="false" Theme="SkinFile" %>


<%@ Register Src="Controls/ctlAbsenceMap.ascx" TagName="ctlAbsenceMap" TagPrefix="uc1" %>
<style>
    .xFormView{
        margin-left:2px !important;
    }
    .tooltip-inner {
    /* If max-width does not work, try using width instead */
    width: auto;
    }

    .absenceTimeOffTypeLegend{
        position : absolute;
        top:25px;
        right: 250px;
    }
    .absenceTimeOffTypeLegend tbody tr{
        line-height:26.1px;
        border-style:solid;
        border-color:black;
        border-width:thin;
    }

    @media only screen and (max-width : 1400px){
        .absenceTimeOffTypeLegend{
            top :380px;
            left: 10px;
       }
        .absenceTimeOffTypeLegend tbody tr{
            line-height:26.1px;
        }
        .xGridViewTS2{
            margin-top:350px;
        }
    }

  
</style>

<script src="../js/libs/bootstrap/jquery-1.9.1.min.js" type="text/javascript"></script>

<script>  
    
    function anchorToTable() {
        window.scrollTo(0, $('#List').position().top + 4);
    }

    $(document).on('click', 'a#List', function (event) {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $($.attr(this, 'href')).offset().top - 8
        }, 500);
    });

</script>

<body>
    <form runat="server" >
        <div>
            <uc1:ctlAbsenceMap ID="ctlAbsenceMap" runat="server" />
        </div>
    </form>
    
</body>

    <link href="../Styles.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/reset.css">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../css/colors.css">
