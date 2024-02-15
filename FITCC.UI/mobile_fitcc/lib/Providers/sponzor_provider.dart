import 'dart:convert';

import 'package:mobile_fitcc/Models/sponzor.dart';

import 'base_provider.dart';

class   SponzorProvider extends BaseProvider<Sponzor> {
    SponzorProvider() : super("SponzorTakmicar");

  @override
  Sponzor fromJson(data) {
    return Sponzor.fromJson(data);
  }
Future<bool> sendContactEmail(Map<String, dynamic> emailData) async {
  var url = Uri.parse('https://localhost:7247/SponzorTakmicar/SendConfirmationEmail');
    Map<String, String> headers = createHeaders();
  var body = json.encode({
    'sender': emailData['sender'],
    'recipient': emailData['recipient'],
    'subject': emailData['subject'],
    'content': emailData['content']
  });

  try {
    var response = await http!.post(url, headers: headers, body: body);

    if (response.statusCode == 200) {
      print('Email sent successfully.');
      return true;
    } else {
      print('Failed to send email. Status code: ${response.statusCode}');
      return false;
    }
  } catch (e) {
    print('An error occurred: $e');
    return false;
  }
}
}