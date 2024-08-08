import 'package:flutter/material.dart';
import 'package:sorusor/data/models/user_dto.dart';
import 'package:sorusor/domain/usecases/get_user_data.dart';

class UserListPage extends StatelessWidget {
  final GetUserData getUserData;

  const UserListPage({super.key, required this.getUserData});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('User List')),
      body: FutureBuilder<List<UserDto>>(
        future: getUserData.execute(),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: CircularProgressIndicator());
          } else if (snapshot.hasError) {
            return Center(child: Text('Error: ${snapshot.error}'));
          } else if (snapshot.hasData) {
            final users = snapshot.data!;
            return ListView.builder(
              itemCount: users.length,
              itemBuilder: (context, index) {
                final user = users[index];
                return ListTile(
                  title: Text(user.userName ?? 'No Name'),
                  subtitle: Text(user.nickName ?? 'No Nickname'),
                );
              },
            );
          } else {
            return const Center(child: Text('No data available'));
          }
        },
      ),
    );
  }
}
