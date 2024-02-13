import 'package:json_annotation/json_annotation.dart';
part 'update_dogadjaj.g.dart';

@JsonSerializable()
class DogadjajUpdateRequest {
  String naziv;
  int trajanje;
  int agendaId;
  DateTime pocetak;
  DateTime kraj;
  String? napomena;
  String lokacija;


  DogadjajUpdateRequest(
      this.naziv,
      this.trajanje,
      this.pocetak,
      this.kraj,
      this.napomena,
      this.agendaId,
      this.lokacija);

  factory DogadjajUpdateRequest.fromJson(Map<String, dynamic> json) =>
      _$DogadjajUpdateRequestFromJson(json);

  Map<String, dynamic> toJson() => _$DogadjajUpdateRequestToJson(this);
}
