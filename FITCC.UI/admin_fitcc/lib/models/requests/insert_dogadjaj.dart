import 'package:json_annotation/json_annotation.dart';
part 'insert_dogadjaj.g.dart';

@JsonSerializable()
class DogadjajInsertRequest {
  String? naziv;
  int? trajanje;
  int? agendaId;
  DateTime? pocetak;
  DateTime? kraj;
  String? napomena;
  String? lokacija;


  DogadjajInsertRequest(
      this.naziv,
      this.trajanje,
      this.pocetak,
      this.kraj,
      this.napomena,
      this.agendaId,
      this.lokacija);

  factory DogadjajInsertRequest.fromJson(Map<String, dynamic> json) =>
      _$DogadjajInsertRequestFromJson(json);

  Map<String, dynamic> toJson() => _$DogadjajInsertRequestToJson(this);
}
