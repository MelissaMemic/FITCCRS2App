import 'package:admin_fitcc/providers/login_provider.dart';
import 'package:admin_fitcc/screens/login_page.dart';
import 'package:admin_fitcc/screens/welcome/home_page.dart';
import 'package:flutter/material.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  var routes = {
    "/homePage": (context) => MyHomePage(),
    "/login": (context) => LoginScreen(),
  };
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
        useMaterial3: true,
      ),
      home:  const LoginScreen(),
      routes: routes,
    );
  }
}
