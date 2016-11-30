<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateApplicant.aspx.cs" Inherits="SASSMMS.WebUI.UI.CreateApplicant" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI.Skins" Assembly="Telerik.Web.UI.Skins, Version=2014.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="telerik1" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2014.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <asp:Panel ID="Panel1" runat="server" BorderColor="#999999" BorderWidth="1">

            <table class="formTableCss">
                <tr>
                    <td id="firstTd">
                        <asp:ImageButton ID="rdAddNew" runat="server" ImageUrl="~/Content/Images/ButtonBarAdd.gif"
                            ToolTip="Add New" OnClick="rdAddNew_OnClick" /></td>

                    <td>
                        <asp:Label ID="lblText" runat="server" CssClass="lblText" Text="Mantain Intra-Transfer"></asp:Label>
                    </td>
                </tr>
            </table>

        </asp:Panel>
        <telerik:RadGrid  ID="gridId"   AllowPaging="True" PageSize="100" OnNeedDataSource="dgIntraTransfer_OnNeedDataSource"
            AllowSorting="True" AutoGenerateColumns="False" CssClass="radGridCss" Skin="Vista" OnEditCommand="dgIntraTransfer_OnEditCommand" OnItemDataBound="dgIntraTransfer_OnItemDataBound"  AllowMultiRowSelection="True">
            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                <Selecting AllowRowSelect="True" />
               
            </ClientSettings>

            <MasterTableView  DataKeyNames="IntraTransferID" >
               
                <Columns>

                  <telerik1:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumber" runat="server" Width="30px" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                            </telerik1:GridTemplateColumn>
                    <telerik1:GridBoundColumn DataField="ApplicantID" FilterControlAltText="Filter ApplicantFirstName column"
                        SortExpression="" Visible="false" UniqueName="Applicant">
                    </telerik1:GridBoundColumn>

                    <telerik1:GridBoundColumn DataField="ApplicantFullName" FilterControlAltText="Filter  ApplicantFirstName column"
                        HeaderText="Applicant Full Name" SortExpression="ApplicantFullName"
                        UniqueName="ApplicantFullName">
                    </telerik1:GridBoundColumn>

                    <telerik1:GridBoundColumn DataField="SourceProgram" FilterControlAltText="Filter SourceProgram column"
                        HeaderText="Source Program" SortExpression="SourceProgram" UniqueName="SourceProgram">
                    </telerik1:GridBoundColumn>
                    <telerik1:GridBoundColumn DataField="TargetProgram" FilterControlAltText="Filter TargetProgram column"
                        HeaderText="Target Program" SortExpression="TargetProgram" UniqueName="TargetProgram">
                    </telerik1:GridBoundColumn>
                    <telerik1:GridBoundColumn DataField="RequestedDate" DataType="System.DateTime" 
                        DataFormatString="{0:dd/MM/yyyy}"
                        FilterControlAltText="Filter RequestedDate column" HeaderText="Requested Date"
                        SortExpression="RequestedDate" UniqueName="RequestedDate">
                    </telerik1:GridBoundColumn>

                    <telerik1:GridBoundColumn DataField="TransferStatus" FilterControlAltText="Filter TransferStatus column"
                        HeaderText="Transfer Status" SortExpression="TransferStatus" UniqueName="TransferStatus">
                    </telerik1:GridBoundColumn>
                    <telerik1:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" Text="Detail">
                    </telerik1:GridButtonColumn>
                    <telerik1:GridBoundColumn DataField="IntraTransferID" DataType="System.Guid"
                        FilterControlAltText="Filter IntraTransferID column" HeaderText="IntraTransferID"
                        SortExpression="IntraTransferID" UniqueName="IntraTransferID" Display="false">
                    </telerik1:GridBoundColumn>
                </Columns>
            </MasterTableView>

           
        </telerik:RadGrid>

        

    </div>
</asp:Content>
