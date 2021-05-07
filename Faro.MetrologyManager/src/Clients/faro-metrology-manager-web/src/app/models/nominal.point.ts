import { AveragePointFromActualPoints } from './average.point';

export class NominalPoint {
  id?: number;
  executionUser?: string;
  name?: string;
  x?: number;
  y?: number;
  z?: number;
  averagePointFromActualPoints!: AveragePointFromActualPoints;
}
