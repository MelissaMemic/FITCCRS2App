import 'package:json_annotation/json_annotation.dart';

enum Role {
  @JsonValue(0)
  admin,
  @JsonValue(1)
  ziri,
  @JsonValue(2)
  takmicar,
  @JsonValue(3)
  sponzor
}
