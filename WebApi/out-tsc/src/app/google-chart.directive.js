"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var GoogleChartDirective = /** @class */ (function () {
    function GoogleChartDirective(element) {
        this.element = element;
        this.loadingDelay = 0;
        this.itemSelect = new core_1.EventEmitter();
        this.itemDeselect = new core_1.EventEmitter();
        this._element = this.element.nativeElement;
    }
    GoogleChartDirective.prototype.ngOnChanges = function () {
        var _this = this;
        if (!googleLoaded) {
            googleLoaded = true;
            google.charts.load('current', { 'packages': ['corechart', 'gauge']['orgchart'] });
        }
        setTimeout(function () { return _this.drawGraph(_this.chartOptions, _this.chartType, _this.chartData, _this._element); }, this.loadingDelay);
    };
    GoogleChartDirective.prototype.onResize = function (event) {
        this.drawGraph(this.chartOptions, this.chartType, this.chartData, this._element);
    };
    GoogleChartDirective.prototype.drawGraph = function (chartOptions, chartType, chartData, ele) {
        google.charts.setOnLoadCallback(drawChart);
        var self = this;
        function drawChart() {
            var wrapper = new google.visualization.ChartWrapper({
                chartType: chartType,
                dataTable: chartData,
                options: chartOptions || {}
            });
            wrapper.draw(ele);
            google.visualization.events.addListener(wrapper, 'select', function () {
                var selectedItem = wrapper.getChart().getSelection()[0];
                if (selectedItem) {
                    var msg = void 0;
                    if (selectedItem !== undefined) {
                        var selectedRowValues = [];
                        if (selectedItem.row !== null) {
                            selectedRowValues.push(wrapper.getDataTable().getValue(selectedItem.row, 0));
                            selectedRowValues.push(wrapper.getDataTable().getValue(selectedItem.row, selectedItem.column));
                            msg = {
                                message: 'select',
                                row: selectedItem.row,
                                column: selectedItem.column,
                                selectedRowValues: selectedRowValues
                            };
                        }
                    }
                    self.itemSelect.emit(msg);
                }
                else
                    self.itemDeselect.emit();
            });
        }
    };
    __decorate([
        core_1.Input('chartType'),
        __metadata("design:type", String)
    ], GoogleChartDirective.prototype, "chartType", void 0);
    __decorate([
        core_1.Input('chartOptions'),
        __metadata("design:type", Object)
    ], GoogleChartDirective.prototype, "chartOptions", void 0);
    __decorate([
        core_1.Input('loadingDelay'),
        __metadata("design:type", Object)
    ], GoogleChartDirective.prototype, "loadingDelay", void 0);
    __decorate([
        core_1.Input('chartData'),
        __metadata("design:type", Object)
    ], GoogleChartDirective.prototype, "chartData", void 0);
    __decorate([
        core_1.Output('itemSelect'),
        __metadata("design:type", core_1.EventEmitter)
    ], GoogleChartDirective.prototype, "itemSelect", void 0);
    __decorate([
        core_1.Output('itemDeselect'),
        __metadata("design:type", core_1.EventEmitter)
    ], GoogleChartDirective.prototype, "itemDeselect", void 0);
    __decorate([
        core_1.HostListener('window:resize'),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", [Event]),
        __metadata("design:returntype", void 0)
    ], GoogleChartDirective.prototype, "onResize", null);
    GoogleChartDirective = __decorate([
        core_1.Directive({
            selector: '[GoogleChart]'
        }),
        __metadata("design:paramtypes", [core_1.ElementRef])
    ], GoogleChartDirective);
    return GoogleChartDirective;
}());
exports.GoogleChartDirective = GoogleChartDirective;
//# sourceMappingURL=google-chart.directive.js.map