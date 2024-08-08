import 'package:flutter/material.dart';
import 'package:sorusor/core/services/api_service.dart';
import 'package:sorusor/data/datasources/remote_data_source.dart';
import 'package:sorusor/data/repositories/user_repository.dart';
import 'package:sorusor/domain/usecases/get_user_data.dart';
import 'package:sorusor/presentation/pages/user_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    // API Service ve Repository yapılandırması
    final apiService =
        ApiService('http://192.168.1.100:8080/api'); // API base URL
    final remoteDataSource = RemoteDataSource(apiService);
    final userRepository = UserRepository(remoteDataSource);
    final getUserData =
        GetUserData(userRepository); // GetUserData nesnesini oluşturuyoruz

    return MaterialApp(
      title: 'User List App',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: HomePage(getUserData: getUserData),
    );
  }
}

class HomePage extends StatelessWidget {
  final GetUserData getUserData;

  const HomePage({super.key, required this.getUserData});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Home Page')),
      body: Center(
        child: ElevatedButton(
          onPressed: () {
            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => UserListPage(getUserData: getUserData),
              ),
            );
          },
          child: const Text('Go to User List'),
        ),
      ),
    );
  }
}
