<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ByWarehouse.aspx.cs" Inherits="_Git_.ByWarehouse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">
        <div id="content" class="mt-5 ml-5 mr-5">

            <!-- Begin Page Content -->
            <div class="container-fluid">

                <table border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:DropDownList class="btn btn-outline-dark btn-rounded" ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button class="btn btn-success btn-rounded" Text="Populate" runat="server" OnClick="PopulateChart1" />
                <hr />
                <br />

                <!-- Content Row -->
                <div class="row">

                    <!-- Summary of Each Warehouses -->
                    <div class="col-lg-12">
                        <div class="card shadow mb-3">
                            <div class="card-header">
                                <h6 class="mt-2 font-weight-bold text-primary">Summary According to Warehouse</h6>
                            </div>
                            <div class="card-body">
                                <asp:Chart ID="Chart4" runat="server" Width="1500px" Height="530px" Visible="false">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="date" YValueMembers="incoming" LegendText="Incoming"
                                            IsValueShownAsLabel="true" ChartArea="ChartArea1" MarkerStyle="Circle" Color="#C6D57E">
                                        </asp:Series>
                                    </Series>
                                    <Series>
                                        <asp:Series Name="Series2" XValueMember="date" YValueMembers="outgoing" LegendText="Outgoing"
                                            IsValueShownAsLabel="true" ChartArea="ChartArea1" MarkerStyle="Circle" Color="#D57E7E">
                                        </asp:Series>
                                    </Series>
                                    <Series>
                                        <asp:Series Name="Series3" ChartType="Line" XValueMember="date" YValueMembers="totalstorage" LegendText="Total Storage"
                                            IsValueShownAsLabel="true" ChartArea="ChartArea1" MarkerStyle="Circle" Color="#BAABDA">
                                        </asp:Series>
                                    </Series>
                                    <Series>
                                        <asp:Series Name="Series4" ChartType="Line" XValueMember="date" YValueMembers="maximumcapacity" LegendText="Maximum Capacity"
                                            IsValueShownAsLabel="true" ChartArea="ChartArea1" MarkerStyle="Circle" Color="#876445">
                                        </asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                    </Legends>
                                    <Titles>
                                        <asp:Title Docking="Top" Text="Summary of Incoming, Outgoing, Total Storage, and Maximum Capacity (All Warehouses)" />
                                    </Titles>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>

                    <!-- Incoming -->
                    <div class="col-lg-6">
                        <div class="card shadow mb-3">
                            <div class="card-header">
                                <h6 class="mt-2 font-weight-bold text-primary">Summary of Incoming</h6>
                            </div>
                            <div class="card-body">
                                <asp:Chart ID="Chart2" runat="server" Width="700px" Height="430px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="date" YValueMembers="incoming" LegendText="Incoming"
                                            IsValueShownAsLabel="true" ChartArea="ChartArea1" MarkerStyle="Circle" Color="#C6D57E">
                                        </asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                    </Legends>
                                    <Titles>
                                        <asp:Title Docking="Top" Text="Incoming" />
                                    </Titles>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>


                    <!-- Outgoing -->
                    <div class="col-lg-6">
                        <div class="card shadow mb-3">
                            <div class="card-header">
                                <h6 class="mt-2 font-weight-bold text-primary">Summary of Outgoing </h6>
                            </div>
                            <div class="card-body">
                                <asp:Chart ID="Chart3" runat="server" Width="700px" Height="430px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="date" YValueMembers="outgoing" LegendText="Outgoing"
                                            IsValueShownAsLabel="true" ChartArea="ChartArea1" MarkerStyle="Circle" Color="#D57E7E">
                                        </asp:Series>
                                    </Series>
                                    <Legends>
                                        <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                    </Legends>
                                    <Titles>
                                        <asp:Title Docking="Top" Text="Outgoing" />
                                    </Titles>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>


                    <!-- Summary of Car Model according to Warehouses -->

                    <div class="col-lg-12">
                        <div class="card shadow mb-3">
                            <div class="card-header">
                                <h6 class="mt-2 font-weight-bold text-primary">Summary of Car Model according to Warehouses</h6>
                            </div>
                            <div class="row m-1">

                                <!-- Accord -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">Accord</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart5" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="accord" LegendText="Accord"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#ccdbfd">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of Accord" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- Civic -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">Civic</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart6" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="civic" LegendText="Civic"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#9cadce">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of Civic" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- Jazz -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">Jazz</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart1" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="jazz" LegendText="Jazz"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#d3ab9e">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of Jazz" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- City -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">City</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart9" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="city" LegendText="City"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#ff8fab">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of City" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- CRV -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">CRV</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart14" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="crv" LegendText="CRV"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#84dcc6">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of CRV" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- HRV -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">HRV</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart7" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="hrv" LegendText="HRV"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#9cf6f6">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of HRV" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- BRV -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">BRV</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart8" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="brv" LegendText="BRV"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#dfb2f4">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of BRV" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- Jazz HEV -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">Jazz HEV</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart11" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="jazzhev" LegendText="Jazz HEV"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#f6bc66">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of Jazz HEV" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>

                                <!-- HRV HEV -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">HRV HEV</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart12" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="hrvhev" LegendText="HRV HEV"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#218B82">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of HRV HEV" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>


                                <!-- City HEV -->
                                <div class="card-body col-4">
                                    <div class="card shadow">
                                        <div class="card-header">
                                            <h6 class="mt-2 font-weight-bold text-primary">City HEV</h6>
                                        </div>
                                        <div class="card-body">
                                            <asp:Chart ID="Chart13" runat="server" Width="430px" Height="300px" Visible="false">
                                                <Series>
                                                    <asp:Series XValueMember="date" YValueMembers="cityhev" LegendText="City HEV"
                                                        IsValueShownAsLabel="true" ChartArea="ChartArea1" Color="#CCD4BF">
                                                    </asp:Series>
                                                </Series>
                                                <Legends>
                                                    <asp:Legend Title="Keys" Docking="Bottom" Alignment="Center" />
                                                </Legends>
                                                <Titles>
                                                    <asp:Title Docking="Top" Text="Daily Record of City HEV" />
                                                </Titles>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
