<template>
    <!--本页面为学生点击查看老师评语按钮后的页面-->
    <div class="studentCorrectList">
        <div class="top">
            <rel-row class="p">
                <span id="p1">请选择班级: </span>
                <!--请选择你的班级-->
                <el-select v-model="classNumSelected" placeholder="please select your class" @change="SelectClass">
                    <el-option v-for="(course,index) in classInfo" :label="course.courseName" :value="index" :key="index" />
                </el-select>

                <!--此处为新加的选择按钮，在这里可以添加班级，添加的班级会传到classNum中-->
                <el-button id="bu2" type="primary" @click="dialogVisible=true">添加班级</el-button>
                <el-dialog
                    v-model="dialogVisible"
                    title="添加班级"
                    width="30%"
                    height="50%"
                    :before-close="handleClose"
                >
                    <el-form>
                        <el-form-item label="班级号  " label-width="30%">
                            <el-input v-model="new_classId"></el-input>
                        </el-form-item>
                        <el-form-item label="代码库链接" label-width="30%">
                            <el-input v-model="new_classUrl"></el-input>
                        </el-form-item>
                    </el-form>    
                
                    <template #footer>
                        <el-button @click="dialogVisible = false" margin-top="10px">取消添加</el-button>
                        <el-button type="primary" @click="addClass" margin-top="10px">
                        添加
                        </el-button>
                    </template>
                </el-dialog>
        
                <span id="p2"><el-text size="large" type="warning"> {{ inputAddress }}</el-text> 
                <!--点击代码库地址之后可以修改代码库-->
                <el-button id="addr" type="warning" @click="select()">查询</el-button>  
                </span>
       
            </rel-row>
        </div>

        <el-table :data="Assignment" border height="400" style="width: 100%" :row-class-name="rowStyle" @row-click="GoTo">
            <el-table-column prop="index" label="作业号" width="180" />
            <el-table-column prop="desc" label="作业名" width="180" />
            <el-table-column prop="endTime" label="截止日期" width="180" />
            <el-table-column prop="submit_state" label="提交状态" width="180" />
            <el-table-column prop="correct_state" label="批改状态" width="180" /> 

        </el-table>
        <!--返回按钮-->
    </div>

</template>
      
<script>
import axios from '../../api/config'
import { ElMessage, ElMessageBox } from 'element-plus'
export default{

    name:"StudentCorrectListPage",
    data(){

        return{
            //TODO: 后端传进来username作为欢迎语
            username: "张三",
            //TODO: 后端传进来的作业号和批改状态,true表示已批改，false表示未批改，
            //TODO: 还要实现一个功能是点击查看批改情况之后跳转到批改界面，然后可以查看老师的批改情况（针对每一行代码），这里我不太明白怎么实现，交给你了
            Assignment:[],
            classNumSelected:null,
            inputAddress:"",
            new_classId:null,
            new_classUrl:"",
            dialogVisible:false,
  
        }
    },
    methods:{
        addClass(){
          //
            if(this.new_classUrl==""){
                ElMessage(
                    {
                        type:"warning",
                        message:"请完善表单"
                    }
                );
                return;
            }else{
           

                axios.get('api/StudentGertCorrection/addClass?classId=' + 
                    this.new_classId+'&studentId='+this.$cookies.get("userInfo").userId
                    +'&url='+this.new_classUrl).then(
                    response => {
                            ElMessage(
                                {
                                    type:"success",
                                    message:"成功"
                                }
                            );
                    })
            }
        },

        addUrl(){
            ElMessageBox.prompt('请输入代码库地址', '添加代码库', {

                confirmButtonText: 'OK',
                cancelButtonText: 'Cancel',

                }).then(({ value }) => {
                    if(this.inputAddress==""){
                        this.inputAddress = value
                    }
                    
                }
                ).catch(() => {
                }
            )
        },
        SelectClass(e){
            this.inputAddress = this.classInfo[e].url
        },
        select(){
            if(this.classNumSelected==null){
                ElMessage(
                    {
                        type:"warning",
                        message:"请选择班级"
                    }
                );
                return
            }
            axios.get('api/TeacherWork/getTask?id=' + this.classInfo[this.classNumSelected].id).then(
                response => {
                    console.log(response.data);
                    var index = 0
                    for(var raw in response.data){
                        this.Assignment.push(
                            {
                                "index":index,
                                "desc":response.data[raw].desc,
                                "endTime":response.data[raw].endTime,
                                "submit_state":"否",
                                "correct_state":"否"
                            }
                        )
                        index += 1
                    }
                    axios.get('api/TeacherWork/getSubmit?studentId=' + 
                        this.$cookies.get("userInfo").userId+"&classId="+
                        this.classInfo[this.classNumSelected].id).then(
                        response => {
                            console.log(response.data);
                            for(var e in response.data){
                                this.Assignment[response.data[e].index-1].submit_state = "是"
                            }
                        }
                    )
                    axios.get('api/TeacherWork/getCorrect?studentId=' + 
                        this.$cookies.get("userInfo").userId+"&classId="+
                        this.classInfo[this.classNumSelected].id).then(
                        response => {
                            console.log(response.data);
                            
                            for(var e in response.data){
                                console.log(response.data[e]-1)
                                this.Assignment[response.data[e]-1].correct_state = "是"
                            }
                        }
                    )       
                }
            )
            
            
        } ,
        rowStyle({row, rowIndex}){
                if(row.submit_state=="否"){
                    return 'error_class';
                }
                else if(row.correct_state=="是"){
                    return 'success_class';
                }
                else{
                    return ""
                }
        } ,
        GoTo(data) {
            if(data.correct_state=="否"){
                return
            }
            console.log(data)
            this.$router.push('/StudentCorrectPage?classId=' + this.classInfo[this.classNumSelected].id 
            + '&studentId=' + this.$cookies.get("userInfo").userId + '&workIndex=' +(parseInt(data.index)+1))
        },        
    },
    created() {
        axios.get('api/StudentGertCorrection/getClass?id=' + this.$cookies.get("userInfo").userId).then(
                response => {
                    this.classInfo = response.data;
                    console.log(this.classInfo);
                    this.$forceUpdate();
                }
            )
    },
} 
</script>
      
<style lang="scss" scoped>
    .studentCorrectList{
        width: 100%;
        background-image: url('../../public/images/svgs/login-bg.svg');
        .top{
            .p{font-size:15px; color:white;}
            #p1{margin-left:5px;}
            .m-2{margin-left:5px;}
            #bu2{margin-left:1px;}
            
            #p2{ float:right; #addr{margin-left:3px;}}
        }
    }
    h1,span{
        color:#f9cdaa;
    }
</style>
<style>
    .error_class{
        color: red;
    }
    .success_class{
        color: green;
    }
</style>
      