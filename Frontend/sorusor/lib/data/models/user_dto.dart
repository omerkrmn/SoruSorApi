class UserDto {
  int? id;
  String? userName;
  String? password;
  String? nickName;
  String? mail;

  UserDto({this.id, this.userName, this.password, this.nickName, this.mail});

  UserDto.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    userName = json['userName'];
    password = json['password'];
    nickName = json['nickName'];
    mail = json['mail'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['id'] = id;
    data['userName'] = userName;
    data['password'] = password;
    data['nickName'] = nickName;
    data['mail'] = mail;
    return data;
  }
}
