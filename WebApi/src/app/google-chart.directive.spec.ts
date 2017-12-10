import { GoogleChartDirective } from './google-chart.directive';
import { ElementRef } from '@angular/core';

describe('GoogleChartDirective', () => {
  it('should create an instance', () => {
    let element;
    let elem = new ElementRef(element);
    const directive = new GoogleChartDirective(elem);
    expect(directive).toBeTruthy();
  });
});
