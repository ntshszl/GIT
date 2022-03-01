<%@ Page Title="June Upload File" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="June.aspx.cs" Inherits="_Git_.June" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content-wrapper" class="d-flex flex-column">
        <!-- Main Content -->
        <div id="content" class="mt-5 ml-5 mr-5">
            <h3>
                <center>
                    June
                </center>
            </h3>
            <hr />
            <div class="ml-5 mt-5 mr-5">
                <h4>Import Excel</h4>
                <h6>Add new information by uploading file below.</h6>
                <h6>The file format should be in .xls or .xlsx format. </h6>
                <br />
                <div class="card-excelupload">
                    <p>Please drag/upload file here.</p>
                    <div class="excel-fileupload">
                    </div>
                </div>
                      <asp:Table ID="Table1" runat="server" CellPadding="10" GridLines="Both"  Width="100%">

                    <asp:TableRow>
                        <asp:TableHeaderCell><center>Warehouse</center></asp:TableHeaderCell>
                        <asp:TableHeaderCell><center>Upload File</center></asp:TableHeaderCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell><center>NISSIN PUNCAK ALAM ZONE 5</center></asp:TableCell>
                        <asp:TableCell>
                            <center>
                                <asp:FileUpload class="btn btn-dark shadow m-3" ID="FileUploadExcel" runat="server" />
                                <asp:Button class="btn btn-primary shadow" ID="btnUpload" runat="server" OnClick="UploadExcel_Click" Text="Upload File" />
                                <asp:Label ID="UploadLabel" runat="server" Text=" "></asp:Label>
                            </center>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell><center>NISSIN PUNCAK ALAM ZONE 7</center></asp:TableCell>
                        <asp:TableCell>
                            <center>
                                <asp:FileUpload class="btn btn-dark shadow m-3" ID="UploadExcel2" runat="server" />
                                <asp:Button class="btn btn-primary shadow" ID="Button1" runat="server" OnClick="UploadExcel_Click2" Text="Upload File" />
                                <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                            </center>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell><center>SCHENKER</center></asp:TableCell>
                        <asp:TableCell>
                            <center>
                                <asp:FileUpload class="btn btn-dark shadow m-3" ID="UploadExcel3" runat="server" />
                                <asp:Button class="btn btn-primary shadow" ID="Button2" runat="server" OnClick="UploadExcel_Click3" Text="Upload File" />
                                <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
                            </center>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell><center>TIONG NAM</center></asp:TableCell>
                        <asp:TableCell>
                            <center>
                                <asp:FileUpload class="btn btn-dark shadow m-3" ID="UploadExcel4" runat="server" />
                                <asp:Button class="btn btn-primary shadow" ID="Button3" runat="server" OnClick="UploadExcel_Click4" Text="Upload File" />
                                <asp:Label ID="Label3" runat="server" Text=" "></asp:Label>
                            </center>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
            </div>
        </div>
</asp:Content>
