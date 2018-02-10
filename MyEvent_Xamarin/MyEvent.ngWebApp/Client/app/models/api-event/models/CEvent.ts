/* tslint:disable */
import { CLocationInfo } from "./CLocationInfo"
import { CScheduleInfo } from "./CScheduleInfo"
import { CPlannedActivity } from "./CPlannedActivity"

export class CEvent {
		sName: string;
		idPrimaryLocationID: string;
		idScheduleInfoID: string;
		idRowID: string;

		oPrimaryLocation: CLocationInfo;
		oScheduleInfo: CScheduleInfo;
		oPlannedActivityList: CPlannedActivity[];
}
