import 'package:json_annotation/json_annotation.dart';
import 'package:mobile_fitcc/Models/projekat.dart';

part 'rezultat.g.dart';

@JsonSerializable(explicitToJson: true)
class Rezultat {
  int rezultatId;
   int bod;
   String napomena;
   int projekatId;
   Projekat projekat; 
  Rezultat(
 this.rezultatId,
    this.bod,
    this.napomena,
    this.projekatId,
    this.projekat
    );

  factory Rezultat.fromJson(Map<String, dynamic> json) => _$RezultatFromJson(json);
  Map<String, dynamic> toJson() => _$RezultatToJson(this);
}
