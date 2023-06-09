<template>

    <el-aside id="treeView"> 
        <span v-show="filename">
            <div v-for="(d,index) in filename" :key="index">
                <el-button class="label" @click="change(d)">
                    {{d.split('/').pop()}}
                </el-button>
            </div>
            
        </span>
    </el-aside>
    <el-main style="height: 70%;">
        
        <el-card class="box-card">

            <template #header>
                <div class="card-header">
                    <span>{{title}}</span>
                </div>
            </template>
            
            <el-scrollbar style = "height: 65vh;">
            <el-text id="code">
                <el-text v-for="(data,index) in code_data" :key="index">
                    <el-text v-if="data.correct_info==''">
                        {{data.code}}
                    </el-text>
                    <el-popover v-else
                        placement="top-start"
                        title="批改"
                        :width="200"
                        trigger="hover"
                        :content="data.correct_info"
                    >
                        <template #reference>
                            <el-text type="danger" @click="getDesc(index)">
                                {{data.code}}
                            </el-text>
                        </template>
                    </el-popover>
                </el-text>
            </el-text>
            </el-scrollbar>
        </el-card>
    </el-main>
</template>

<script>
    import { file } from '@babel/types';
    import axios from '../../api/config'
    import { ElMessage, ElMessageBox } from 'element-plus'
    export default {
        name: "StudentCorrectCodePage",

        data() {
            return {
                code_data: [
                    {
                        code: "请点击右侧按钮",
                        flagged: false,
                        correct_info: ""
                    },
                ],
                treeProps: {
                    children: "",
                    label: 'path'
                },
                filename: null,
                data:null,
                title:""
            }
        },
        methods:{
            getDesc(index){
                ElMessageBox.alert(this.code_data[index].correct_info, "批改内容", {
                    confirmButtonText: 'OK',
                }).then(() => {
                }).catch(() => {
                });
            },
            unique(arr, key){
                let hash = {};
                const newArr = arr.reduce((preVal, curVal) => {
                    hash[curVal[key]] ? '' : hash[curVal[key]] = true && preVal.push(curVal);
                    return preVal
                }, [])
                return newArr
            },
            change(d){
                this.code_data = this.data[d]
                this.title = d
            }
        },
        created() {
            var q = this.$route.query
            axios.get('api/StudentGertCorrection?courseId='+q.classId+'&studentId='+q.studentId+'&workIndex='+q.workIndex).then(
                response => {
                    this.data =response.data
                    this.data = this.data.reduce((group, t) => {
                        const { path } = t;
                        group[path] = group[path] ?? [];
                        group[path].push(t);
                        return group;
                        }, {});
                    
                    this.filename = Array.from(new Set(response.data.map(item => item.path)))
                    console.log(this.filename)
                }
            )
            

        }
    };
</script>

<style>
    #treeView {
        width: 250px;
        float: Left;
        margin-top: 50px;
    }

    #code {
        white-space: pre;
        width: 100%;
        outline: none;
        min-width: 600px;
    }

    .card-header {
        height: 5vh;
    }

    .box-card {
        height: 80vh;
    }
    .label{
        
        width: 200px;
    }
</style>