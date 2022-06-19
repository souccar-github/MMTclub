import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CreateXxxDto,
    XxxServiceProxy
    //import proxy endTag
} from '@shared/service-proxies/service-proxies';
import { NbDialogRef } from '@nebular/theme';
import { L10n, setCulture, loadCldr } from '@syncfusion/ej2-base';
import { LocalizationHelper } from '@shared/localization/localization-helper';
//import endTag

setCulture('ar-SY');
L10n.load(LocalizationHelper.getArabicResources());

@Component({
    templateUrl: 'create-xxx-dialog.component.html',
    styleUrls: ['create-xxx-dialog.component.scss'],
    providers: [XxxServiceProxy]
})
export class CreateXxxDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    xxx: CreateXxxDto = new CreateXxxDto();
    //declare endTag
    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _xxxService: XxxServiceProxy,
        //ctor endTag
        public dialogRef: NbDialogRef<CreateXxxDialogComponent>
    ) {
        super(injector);
        loadCldr(
            require("cldr-data/main/ar-SY/numbers.json"),
            require("cldr-data/main/ar-SY/ca-gregorian.json"),
            require("cldr-data/supplemental/numberingSystems.json"),
            require("cldr-data/main/ar-SY/timeZoneNames.json"),
            require('cldr-data/supplemental/weekdata.json')
        );
    }

    ngOnInit(): void {
        //init endTag
    }

    save(): void {
        this.saving = true;

        this._xxxService
            .create(this.xxx)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.dialogRef.close();
                this.onSave.emit();
            });
    }

    //func endTag
}
