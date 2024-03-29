import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/io_client.dart';
import 'package:mobile_fitcc/Models/auth_user.dart';
import 'package:mobile_fitcc/Models/constraints/claim_type.dart';


class AuthProvider with ChangeNotifier {
  late String _baseUrl;

  AuthProvider() {
    _baseUrl = const String.fromEnvironment(
      "IdentityServerUrl",
      defaultValue: "http://127.0.0.1:5001/",
    );
  }

  Future<String> login(String email, String password) async {
    HttpClient httpClient = new HttpClient()
  ..badCertificateCallback = ((X509Certificate cert, String host, int port) => true);
    var uri = Uri.parse('${_baseUrl}login?email=$email&password=$password');

var ioClient = new IOClient(httpClient);
var response = await ioClient.get(uri);


    // var response = await http.get(uri);

    if (_isValidResponse(response)) {
      return response.body;

    } else {
      throw Exception("Response is not valid");
    }
  }

  void getUser(String token) {
    final decodedToken = _decode(token);

    AuthUser.id = int.parse(decodedToken[ClaimType.sid] as String);
    AuthUser.name = decodedToken[ClaimType.name] as String;
    AuthUser.email = decodedToken[ClaimType.email] as String;
    AuthUser.token = token;

    var role = decodedToken[ClaimType.role];

    if (role is List<dynamic>) {
      AuthUser.roles = List<String>.from(decodedToken[ClaimType.role]);
    } else {
      AuthUser.roles.add(role);
    }
  }

  bool _isValidResponse(http.Response response) {
    if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Neispravni kredencijali za prijavu.");
    } else {
      throw Exception("Serverska greška.");
    }
  }

  Map<String, dynamic> _decode(String token) {
    final splitToken = token.split(".");
    if (splitToken.length != 3) {
      throw const FormatException('Invalid token');
    }
    try {
      final payloadBase64 = splitToken[1];
      final normalizedPayload = base64.normalize(payloadBase64);
      final payloadString = utf8.decode(base64.decode(normalizedPayload));
      final decodedPayload = jsonDecode(payloadString);

      return decodedPayload;
    } catch (error) {
      throw const FormatException('Invalid payload');
    }
  }
}
