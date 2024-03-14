import 'package:json_annotation/json_annotation.dart';
part 'insert_tim.g.dart';

@JsonSerializable()
class TimInsertRequest
 {
         String? naziv;
         int? brojClanova;
         int? takmicenjeId;

  TimInsertRequest
(
      this.takmicenjeId,
      this.naziv,
      this.brojClanova
  );

  factory TimInsertRequest.fromJson(Map<String, dynamic> json) =>
      _$TimInsertRequestFromJson(json);

  Map<String, dynamic> toJson() => _$TimInsertRequestToJson(this);
}
