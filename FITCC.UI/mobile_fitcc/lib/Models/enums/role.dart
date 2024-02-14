import 'package:json_annotation/json_annotation.dart';

enum Role {
  @JsonValue(0)
  Admin,
  @JsonValue(1)
  Ziri,
  @JsonValue(2)
  Takmicar,
  @JsonValue(3)
  Sponzor
}
