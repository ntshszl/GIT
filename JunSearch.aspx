<%@ Page Title="June Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JunSearch.aspx.cs" Inherits="_Git_.JunSearch" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content-wrapper" class="d-flex flex-column ">
        <div id="content" class="mt-5 ml-5 mr-5">
            <h3>
                <center>
                    June
                </center>
            </h3>
            <hr />
            <div class="ml-5 mt-5 mr-5 ">
                <div>
                    <h4>Search Location</h4>
                    <h6>Enter Lot Number or Invoice No to locate.</h6>
                    <br />
                    <center>
                        <div class="input-group rounded d-flex flex-column col-xl-10 col-lg-12 col-md-9">
                            <div class="row ">
                                <asp:TextBox ID="TxtSearch" runat="server" Width="90%" Height="40px" class="form-control shadow rounded mr-3" />
                                <asp:Button ID="ButSearch" runat="server" OnClick="ButSearch_Click" Width="8%" Height="40px" class="btn btn-success shadow" Text="Search" />
                            </div>
                            <br />
                            <asp:GridView Width="100%" CssClass="table table-condensed text-center  " GridLines="None" ID="GridView1" runat="server"
                                ShowHeaderWhenEmpty="true" EmptyDataText="No record found!" Font-Names="Nirmala UI" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="warehouse2" HeaderText="Warehouse" />
                                    <asp:BoundField DataField="lotno" HeaderText="Lot Number" />
                                    <asp:BoundField DataField="invoiceno" HeaderText="Invoice Number" />
                                    <asp:BoundField DataField="country" HeaderText="Country" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </center>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
