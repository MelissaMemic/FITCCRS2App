import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:http/io_client.dart';
import 'package:mobile_fitcc/Models/auth_user.dart';
import 'package:mobile_fitcc/Models/paged_result.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  late String _baseUrl;
  late String _endpoint;

  HttpClient client = new HttpClient();
  IOClient? http;

  BaseProvider(String endpoint) {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://127.0.0.1:7247");

    if (_baseUrl.endsWith("/") == false) {
      _baseUrl = _baseUrl + "/";
    }

    _endpoint = endpoint;
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }
  Future<PagedResult<T>> getAll([dynamic search]) async {
    var url = "$_baseUrl$_endpoint";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = getHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);

      var result = PagedResult<T>();

      result.totalCount = data['totalCount'];
      result.totalPages = data['totalPages'];
      result.page = data['page'];
      result.pageSize = data['pageSize'];

      for (var item in data['result']) {
        result.result.add(fromJson(item));
      }

      return result;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<bool> delete(int id) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);

    var response = await http!.delete(uri, headers: getHeaders());

    if (isValidResponseCode(response)) {
      return true;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<T> getById(int id, [dynamic additionalData]) async {
    var url = Uri.parse("$_baseUrl$_endpoint/$id");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Dogodila se greska");
    }
  }

  Future<PagedResult<T>> get([dynamic search]) async {
    var url = "$_baseUrl$_endpoint";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = getHeaders();

    var response = await http!.get(uri, headers: headers);
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);

      var result = PagedResult<T>();

      result.totalCount = data['totalCount'];
      result.totalPages = data['totalPages'];
      result.page = data['page'];
      result.pageSize = data['pageSize'];

      for (var item in data['result']) {
        result.result.add(fromJson(item));
      }
      return result;
    } else {
      throw Exception("Response is not valid");
    }
  }

  Future<T> insert(dynamic request) async {
    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);

    var jsonRequest = jsonEncode(request);

    var response =
        await http!.post(uri, headers: getHeaders(), body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else if (response.statusCode == 400) {
      var data = jsonDecode(response.body);
      throw Exception(data['message']);
    } else {
      throw Exception('Failed to create object');
    }
  }

  dynamic myDateSerializer(dynamic object) {
    if (object is DateTime) {
      return object.toIso8601String();
    }
    return object;
  }

  Future<T?> update(int id, [dynamic request]) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);
    var jsonRequest = jsonEncode(request);

    var response =
        await http!.put(uri, headers: getHeaders(), body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Response is not valid");
    }
  }

  T fromJson(data) {
    throw Exception("Override method");
  }

  Map<String, String> createHeaders() {
    var headers = {
      "Content-Type": "application/json",
      "Authorization": "Bearer ${AuthUser.token ?? ""}"
    };
    return headers;
  }

  String getQueryString(Map params,
      {String prefix = '&', bool inRecursion = false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value as DateTime).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query +=
              getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }

  Map<String, String> getHeaders() => {
        "Content-Type": "application/json",
        "Authorization": "Bearer ${AuthUser.token ?? ""}"
      };

  bool isValidResponseCode(Response response) {
    if (response.statusCode == 200) {
      if (response.body != "") {
        return true;
      } else {
        return false;
      }
    } else if (response.statusCode == 204) {
      return true;
    } else if (response.statusCode == 400) {
      throw Exception("Bad request");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else if (response.statusCode == 403) {
      throw Exception("Forbidden");
    } else if (response.statusCode == 404) {
      throw Exception("Not found");
    } else if (response.statusCode == 500) {
      throw Exception("Internal server error");
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}
