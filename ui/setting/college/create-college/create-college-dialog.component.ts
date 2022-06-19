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
    CreateCollegeDto,
    CollegeServiceProxy
    ,



} from '@shared/service-proxies/service-proxies';
import { NbDialogRef } from '@nebular/theme';
import { L10n, setCulture, loadCldr } from '@syncfusion/ej2-base';
import { LocalizationHelper } from '@shared/localization/localization-helper';
//import endTag

setCulture('ar-SY');
L10n.load(LocalizationHelper.getArabicResources());

@Component({
    templateUrl: 'create-college-dialog.component.html',
    styleUrls: ['create-college-dialog.component.scss'],
    providers: [CollegeServiceProxy]
})
export class CreateCollegeDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    college: CreateCollegeDto = new CreateCollegeDto();
    
    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _collegeService: CollegeServiceProxy,
        
        public dialogRef: NbDialogRef<CreateCollegeDialogComponent>
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
        
    }

    save(): void {
        this.saving = true;

        this._collegeService
            .create(this.college)
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

    
}
