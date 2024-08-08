class ApplicationConstant {
  static final ApplicationConstant _instance = ApplicationConstant._internal();

  ApplicationConstant._internal();
  factory ApplicationConstant() {
    return _instance;
  }

  static const String API_URL = "http://192.168.1.100:8080/api";
  static const String EndPoint_CreateUser = "user/CreateOneUser";
  static const String EndPoint_GetAllUser = "user";
}
