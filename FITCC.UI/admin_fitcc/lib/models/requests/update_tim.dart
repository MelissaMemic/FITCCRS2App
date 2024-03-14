import 'package:json_annotation/json_annotation.dart';
part 'update_tim.g.dart';

@JsonSerializable()
class TimUpdateRequest
 {
         String? naziv;
         int? brojClanova;
         int? takmicenjeId;

  TimUpdateRequest
(
      this.naziv,
      this.brojClanova,
      this.takmicenjeId
  );

  factory TimUpdateRequest.fromJson(Map<String, dynamic> json) =>
      _$TimUpdateRequestFromJson(json);

  Map<String, dynamic> toJson() => _$TimUpdateRequestToJson(this);
}
