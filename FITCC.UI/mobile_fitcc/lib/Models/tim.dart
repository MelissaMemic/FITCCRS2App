import 'package:json_annotation/json_annotation.dart';
import 'package:mobile_fitcc/Models/takmicenje.dart';

part 'tim.g.dart';

@JsonSerializable(explicitToJson: true)
class Tim {
    int timId;
    String? naziv;
    int? brojClanova;
    int? takmicenjeId;
    Takmicenje takmicenje;

  Tim(
     this.timId,
     this.naziv,
     this.brojClanova,
     this.takmicenjeId,
     this.takmicenje,
  );

  factory Tim.fromJson(Map<String, dynamic> json) => _$TimFromJson(json);
  Map<String, dynamic> toJson() => _$TimToJson(this);
}
