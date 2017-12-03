import { Unit } from './unit';
import { PowerCode } from './power_code';

export class ValueDto {
  value: number;
  magnitude: PowerCode;
  unit: Unit;
}

export class YearlyValueDto {
  year: number;
  value: ValueDto;
}
