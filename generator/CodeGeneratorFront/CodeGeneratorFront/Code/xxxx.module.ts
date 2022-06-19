import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ThemeModule } from '@theme/theme.module';
import { CommonModule } from '@angular/common';
import { XxxxRoutingModule } from './xxxx-routing.module';
import { XxxxComponent } from './xxxx.component';
//import endTage
import {
    NbActionsModule,
    NbAlertModule,
    NbButtonModule,
    NbCardModule,
    NbDialogModule,
    NbIconModule,
    NbInputModule,
    NbCheckboxModule,
    NbSelectModule
} from '@nebular/theme';
import { SharedModule } from '@shared/shared.module';
import { FormsModule } from '@angular/forms';
import { HttpClientJsonpModule, HttpClientModule } from '@angular/common/http';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {
    EditService,
    FilterService,
    ForeignKeyService,
    GridModule,
    GroupService,
    PageService,
    SortService,
    ToolbarService
} from '@syncfusion/ej2-angular-grids';
import { NumericTextBoxModule, UploaderModule } from '@syncfusion/ej2-angular-inputs';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { ButtonModule, SwitchModule } from '@syncfusion/ej2-angular-buttons';
import { ToolbarModule } from '@syncfusion/ej2-angular-navigations';



const NB_MODULES = [
    NbActionsModule,
    NbIconModule,
    NbEvaIconsModule,
    NbDialogModule.forChild(),
    NbCardModule,
    NbButtonModule,
    NbInputModule,
    NbSelectModule,
    NbAlertModule,
    NbCheckboxModule
];
const SYNCFUSION_MODULES = [
    GridModule,
    ToolbarModule,
    UploaderModule,
    NumericTextBoxModule,
    DropDownListModule,
    SwitchModule,
    ButtonModule
];

const SYNCFUSION_SERVICES = [
    PageService,
    SortService,
    FilterService,
    GroupService,
    ToolbarService,
    ForeignKeyService,
    EditService
];

@NgModule({
    declarations: [
        XxxxComponent,
        //declare endTage
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        SharedModule,
        ServiceProxyModule,
        ThemeModule,
        XxxxRoutingModule,
        ...SYNCFUSION_MODULES,
        ...NB_MODULES
    ],
    providers: [
        ...SYNCFUSION_SERVICES,
        //Service proxy endTage

    ],
    entryComponents: [

    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class XxxxModule { }
