﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_Git_.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" class="u-image u-logo u-image-1" style="width: 200px" href="img/honda.png" />

    <title>Login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1">
        <body class="bg-gradient-light">
            <div class="container ">

                <!-- Outer Row -->
                <div class="row justify-content-center">

                    <div class="col-xl-10 col-lg-12 col-md-9">

                        <div class="card o-hidden border-0 shadow-lg mx-5 my-5">
                            <div class="card-body p-0">

                                <!-- Nested Row within Card Body -->
                                <div class="col-lg-12 p-5">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                        </div>
                                        <form class="user" runat="server">
                                            <div class="form-group">
                                                <asp:TextBox type="text" runat="server" class="form-control form-control-user"
                                                    ID="InputID" aria-describedby="emailHelp"
                                                    placeholder="StaffID" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox type="password" runat="server" class="form-control form-control-user"
                                                    ID="Password" placeholder="Password" />
                                            </div>
                                            <asp:Button class="btn btn-success btn-user btn-block" ID="btnlogin" Text="Login" runat="server" OnClick="btnlogin_Click" />
                                            </>
                                        </form>
                                        <hr />
                                        <div class="text-center">
                                            <h6 class="h6 text-gray-900 mb-4">Haven't register yet? Sign up now!</h6>
                                        </div>
                                        <div class="text-center">
                                            <a class="medium" runat="server" href="~\Register">Sign Up</a>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>
            </div>



            <!-- Bootstrap core JavaScript-->
            <script src="vendor/jquery/jquery.min.js"></script>
            <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

            <!-- Core plugin JavaScript-->
            <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

            <!-- Custom scripts for all pages-->
            <script src="js/sb-admin-2.min.js"></script>
    </form>
</body>
</html>